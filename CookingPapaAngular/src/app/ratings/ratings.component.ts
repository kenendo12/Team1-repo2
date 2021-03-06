import { Component, OnInit, Input } from '@angular/core';

import { AuthService } from '../auth.service';

import { RecipeReviewVM } from '../Models/recipeReviewVM';
import { ReviewsService } from '../reviews.service';

@Component({
  selector: 'app-ratings',
  templateUrl: './ratings.component.html',
  styleUrls: ['./ratings.component.css']
})
export class RatingsComponent implements OnInit {
  constructor(public auth: AuthService,
    private reviewsService: ReviewsService) { }

  @Input() recipeId: number;
  @Input() creatorId: number;

  currentUser: any;
  userId: number;

  starList: boolean[] = [true, true, true, true, true];// create a list which contains status of 5 stars
  rating: number;
  comment: string;

  review: RecipeReviewVM;
  reviews: RecipeReviewVM[];
  reviewList: any[];
  reviewed: boolean = false;
  showAddReview = false;
  okToSubmit = false;

  //Create a function which receives the value counting of stars click, 
  //and according to that value we do change the value of that star in list.
  setStar(data: any) {
    this.review.recipeReviewRating = data + 1;
    for (var i = 0; i <= 4; i++) {
      if (i <= data) {
        this.starList[i] = false;
      }
      else {
        this.starList[i] = true;
      }
    }
    this.okToSubmit = true;
  }
  submitReview(comment: string) {
    this.review.recipeReviewComment = comment;

    if (this.reviewed) {
      let item = this.reviewList[0];
      item.recipeReviewId = this.review.recipeReviewId,
      item.recipeReviewRating = this.colorStars([true, true, true, true, true], this.review.recipeReviewRating),
      item.recipeReviewComment = comment

      this.reviewList[0] = item;
    }
    else {
      this.reviewList.unshift({
        recipeReviewId: this.review.recipeReviewId,
        recipeReviewRating: this.colorStars([true, true, true, true, true], this.review.recipeReviewRating),
        recipeReviewComment: comment
      });
      this.reviewsService.submitReview(this.review);
    }
    ;
    this.reviewed = true;
  }
  openCloseReview(){
    this.showAddReview = true;
  }
  private getUserId() {
    this.auth.userProfile$.subscribe(data => {
      this.currentUser = data;
      this.userId = <number>+ this.currentUser.sub.toString().substr(6);
    });
  }
  private getReviews() {
    this.reviewsService.getReviews(this.review.recipeId)
      .then(reviews => {
        this.reviews = reviews
        this.setUpReviews();
      });
  }
  private setUpReviews() {
    this.reviewList = [];
    this.reviews.forEach(element => {
      this.reviewList.push({
        recipeReviewId: element.recipeReviewId,
        recipeReviewRating: [true, true, true, true, true],
        recipeReviewComment: element.recipeReviewComment
      });
      let item = this.reviewList[this.reviewList.length - 1];
      item.recipeReviewRating = this.colorStars(item.recipeReviewRating, element.recipeReviewRating);
    });
  }
  private colorStars(item:boolean[], rating:number): boolean[]{
    for (let i = 0; i < item.length; i++) {
      if (i < rating) {
        item[i] = false;
      }
      else {
        item[i] = true;
      }
    }
    return item;
  }
  ngOnInit(): void {
    this.getUserId();
    this.review = {
      recipeReviewId: null,
      recipeId: this.recipeId,
      recipeReviewRating: 0,
      userId: this.userId,
      recipeReviewComment: ''
    }
    this.getReviews();
    console.log('creatorId = ', this.creatorId);
    console.log('userId = ', this.userId);
  }
}
