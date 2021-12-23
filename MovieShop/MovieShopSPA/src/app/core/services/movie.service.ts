import { Injectable } from '@angular/core';
import { MovieCard } from 'src/app/shared/models/movieCard';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient) { }

  getTopGrossingMovies(): Observable<MovieCard[]> {
    return this.http.get<MovieCard[]>(`${environment.apiBaseUrl}movies/toprevenue`);
  }

  getMovieDetails(id: number) {
    // call the api to get movie details, create the model based on json data and return the model
  }
}
