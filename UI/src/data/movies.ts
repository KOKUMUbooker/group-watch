import type { Movie } from "../types/movie";

import imgUrl from "../lib/assets/movie.jpg"

// Movies with IDs
export const movies: Movie[] = [
    {
        id: 1,
        title: "The Shawshank Redemption",
        genre: "Drama",
        releaseDate: new Date("1994-09-23"),
        rating: 9.3,
        imgUrl
    },
    {
        id: 2,
        title: "The Godfather",
        genre: "Crime",
        releaseDate: new Date("1972-03-24"),
        rating: 9.2,
        imgUrl
    },
    {
        id: 3,
        title: "The Dark Knight",
        genre: "Action",
        releaseDate: new Date("2008-07-18"),
        rating: 9.0,
        imgUrl
    },
    {
        id: 4,
        title: "Pulp Fiction",
        genre: "Crime",
        releaseDate: new Date("1994-10-14"),
        rating: 8.9,
        imgUrl
    },
    {
        id: 5,
        title: "Inception",
        genre: "Sci-Fi",
        releaseDate: new Date("2010-07-16"),
        rating: 8.8,
        imgUrl
    },
    {
        id: 6,
        title: "Parasite",
        genre: "Thriller",
        releaseDate: new Date("2019-05-30"),
        rating: 8.6,
        imgUrl
    },
    {
        id: 7,
        title: "La La Land",
        genre: "Musical",
        releaseDate: new Date("2016-12-09"),
        rating: 8.0,
        imgUrl
    },
    {
        id: 8,
        title: "Get Out",
        genre: "Horror",
        releaseDate: new Date("2017-02-24"),
        rating: 7.7,
        imgUrl
    },
    {
        id: 9,
        title: "Spirited Away",
        genre: "Animation",
        releaseDate: new Date("2001-07-20"),
        rating: 8.6,
        imgUrl
    },
    {
        id: 10,
        title: "Interstellar",
        genre: "Sci-Fi",
        releaseDate: new Date("2014-11-07"),
        rating: 8.6,
        imgUrl
    },
    {
        id: 11,
        title: "The Matrix",
        genre: "Action",
        releaseDate: new Date("1999-03-31"),
        rating: 8.7,
        imgUrl
    },
    {
        id: 12,
        title: "Forrest Gump",
        genre: "Drama",
        releaseDate: new Date("1994-07-06"),
        rating: 8.8,
        imgUrl
    },
    {
        id: 13,
        title: "Avengers: Endgame",
        genre: "Action",
        releaseDate: new Date("2019-04-26"),
        rating: 8.4,
        imgUrl
    },
    {
        id: 14,
        title: "Joker",
        genre: "Thriller",
        releaseDate: new Date("2019-10-04"),
        rating: 8.4,
        imgUrl
    },
    {
        id: 15,
        title: "Coco",
        genre: "Animation",
        releaseDate: new Date("2017-11-22"),
        rating: 8.4,
        imgUrl
    }
];