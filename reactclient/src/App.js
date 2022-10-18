import React, { useState } from "react";

export default function App() {
  const [notes, setNotes] = useState([]);
  function getNotes() {
    const url = "https://localhost:7079/api/Note";
    fetch(url, {
      method: "GET",
    })
      .then((response) => response.json())
      .then((notesFromServer) => {
        console.log(notesFromServer);
        setNotes(notesFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <div >
            <h1>Asp .Net Core React To Do List</h1>
            <div className="mt-5">
              <button onClick={getNotes} className="btn btn-dark btn-lg w-100">Get Notes From Server</button>
              <button onClick={()=>{}} className="btn btn-secondary btn-lg w-100 mt-4">Create New Note</button>

            </div>
          </div>
          {renderNotetable()}
        </div>
      </div>
    </div>
  );
  function renderNotetable() {
    return (
      <div className="table-resposive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">NoteID</th>
              <th scope="col">Description</th>
              <th scope="col">UserID</th>
              <th scope="col">CRUD Operation</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <th scope="row"></th>
              <td> </td>
              <td></td>
              <td>
                <button className="btn btn-dark btn-lg mx-3 my-3">
                  Update
                </button>
                <button className="btn btn-secondary btn-lg mx-3 my-3">
                  Remove
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    );
  }
}
