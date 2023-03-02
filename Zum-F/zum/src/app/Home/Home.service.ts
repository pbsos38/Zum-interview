import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Post } from 'src/models/Post';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  getData( tags:any, sort:any,filter:any) {
    let params = new HttpParams();
    params = params.append('tags', tags);
    params = params.append('sortBy', filter);
    params = params.append('direction', sort);


    return this.http.get<Post[]>('https://localhost:7249/Posts',{ params: params });
  }
}
