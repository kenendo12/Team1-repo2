import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-ratings',
  templateUrl: './ratings.component.html',
  styleUrls: ['./ratings.component.css']
})
export class RatingsComponent implements OnInit {
  constructor() { }
  title: string = 'Star Rating';
  starList: boolean[] = [true,true,true,true,true];       // create a list which contains status of 5 stars
  rating:number;  
  //Create a function which receives the value counting of stars click, 
  //and according to that value we do change the value of that star in list.
  setStar(data:any){
        this.rating=data+1;                               
        for(var i=0;i<=4;i++){  
          if(i<=data){  
            this.starList[i]=false;  
          }  
          else{  
            this.starList[i]=true;  
          }  
       }  
   }
  ngOnInit(): void {
  }

}
