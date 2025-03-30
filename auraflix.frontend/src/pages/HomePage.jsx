// src/pages/HomePage.js
import React, { useEffect, useState } from "react";
import "./css/home.css";
import axios from "axios";
import { Link } from "react-router-dom";

const HomePage = () => {
  const [movies, setMovies] = useState([]);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    axios
      .get("http://localhost:5048/api/movie")
      .then((response) => {
        setMovies(response.data);
        setLoading(false);
      })
      .catch((error) => {
        console.error("There was an error fetching the movies!", error);
        setLoading(false);
      });
  }, []);

  if (loading) {
    return <div className="text-white">Loading...</div>;
  }

  return (
    <div className="HomePage">
      <h1 className="text-white pb-5 ">AuraFlix</h1>
      <div className="floating-div">
        <div className="headerDiv">
          <h2 className="text-white">Featured Flix</h2>
        </div>
        <div className="moviesListDiv row d-flex w-100 pt-3 pb-3 justify-content-start">
          {movies.map((movie) => {
            return (
              <div key={movie.movieId} className="col-md-3 col-sm-6 mb-4">
                <div className="card rounded">
                  <img
                    src={movie?.MoviePoster || 'placeholder-image.jpg'} // Add fallback image
                    className="card-img-top"
                    alt={movie?.title || 'Movie poster'}
                  />
                  <div className="card-body">
                    <h5 className="card-title">{movie?.title || 'Untitled'}</h5>
                    <Link
                      to={`/MovieDetailsPage/${movie?.movieId}`}
                      className="btn btn-primary"
                    >
                      Details
                    </Link>
                  </div>
                </div>
              </div>
            );
          })}
        </div>
      </div>
    </div>
  );
};

export default HomePage;
