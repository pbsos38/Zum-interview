import { IPost } from "./IPost.interface"

export class Post implements IPost {
  id: number = 0;
  author: string = '';
  authorId: number = 0;
  likes: number = 0;
  popularity: number = 0;
  reads: number = 0;
  tags: string[] = [];
}

