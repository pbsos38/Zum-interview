import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from 'src/models/Post';
import { HomeService } from './Home.service';

@Component({
  selector: 'app-Home',
  templateUrl: './Home.component.html',
  styleUrls: ['./Home.component.css']
})
export class HomeComponent implements OnInit {

   list: Array<Post> = [];
  constructor(private service: HomeService, private router: Router) { }

  ngOnInit() {
  }

  LoadData( tags:any, sort:any,filter:any) {
    this.list = []

    if(tags==""){
      window.alert("Tags Cannot be Empty!");
      return;
    }

    const user = this.service.getData(tags,sort,filter).subscribe(
      response => {
        console.log(response);
        if(response.length<1){
          window.alert("No Data found!");
          return;
        }
        this.list = response;
        console.log(response);
      }
    );
   }

}
