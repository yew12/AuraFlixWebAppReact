import axios from "axios";
import React, { act, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import "./css/moviedetails.css"

const MovieDetailsPage = () => {
  const [movieDetails, setMovieDetails] = useState({});
  const [loading, setLoading] = useState(true);
  const { id: movieId } = useParams(); // Extract 'id' from the URL parameters

  const fetchMoveDetails = async (movieId) => {
    await axios
      .get(`http://localhost:5048/api/movie/${movieId}`)
      .then((response) => {
        console.log(response.data);
        setMovieDetails(response.data);
        setLoading(false);
      })
      .catch((err) => {
        console.error(err);
        setLoading(false);
      });
  };

  useEffect(() => {
    if (movieId) fetchMoveDetails(movieId);
  }, [movieId]);

  if (loading) {
    return <div className="text-white">Loading...</div>;
  }

  const ActorsList = (actors) => {
    const listItems = [];
    actors.actors.forEach((element) => {
      listItems.push(
        <li key={element.actorId}>
          {element?.actorName} as {element?.role}
        </li>
      );
    });

    return listItems;
  };

  return (
    <div className="movie-details">
      <div className="movie-container">
        <h1 className="movie-title">{movieDetails?.title || "Untitled Movie"}</h1>
        <div className="d-flex flex-column p-2">
          <h2 className="movie-tagline">{movieDetails?.tagline ?? ""}</h2>
          <h6 className="movie-description">{movieDetails?.description || "No description available"}</h6>
          <div className="ratings-container d-flex flex-row justify-content-evenly w-100">
            <h6>Rating: {movieDetails?.rating ?? "N/A"}</h6>
            <h6>Total Ratings: {movieDetails?.totalRatings ?? "0"}</h6>
          </div>
          <div className="actors-section">
            <h6>Actors:</h6>
            <ul className="actors-list">
              <ActorsList actors={movieDetails?.cast} />
            </ul>
          </div>
        </div>
      </div>
    </div>
  );
};

export default MovieDetailsPage;
