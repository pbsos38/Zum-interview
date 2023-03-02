import { Component, Input } from '@angular/core';
import { IPost } from 'src/models/IPost.interface';

@Component({
  selector: 'app-postCard',
  templateUrl: './postCard.component.html',
  styleUrls: ['./postCard.component.css']
})
export class PostCardComponent {
  @Input() Post :IPost;
  constructor() { }

}
