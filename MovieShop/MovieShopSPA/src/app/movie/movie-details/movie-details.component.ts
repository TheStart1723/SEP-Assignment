import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  id: number = 0;
  constructor(private route: ActivatedRoute, private movieService: MovieService) { }

  ngOnInit(): void {

    this.route.paramMap.subscribe(
      p => {
        this.id = Number(p.get('id'));
        console.log('MovieId' + this.id);

      }
    )
  };

}
