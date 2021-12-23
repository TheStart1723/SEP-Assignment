import { Component, OnInit } from '@angular/core';
import { MovieService } from '../core/services/movie.service';
import { MovieCard } from '../shared/models/movieCard';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  movieCards!: MovieCard[];
  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    console.log('inside Home Component Init Method')
    console.table(this.movieCards);
    this.movieService.getTopGrossingMovies()
      .subscribe(
        m => {
          this.movieCards = m;
          console.log('inside the subscribtion');
          console.log(this.movieCards);
        }
      );
  }

}
