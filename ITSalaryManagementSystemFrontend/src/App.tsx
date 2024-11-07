import { useState, useEffect } from "react";
import { RouterProvider } from "react-router-dom";

import { useAppDispatch } from "./reduxs/hooks";
import { fetchUserProfile } from "./reduxs/slices/profileSlice";
import Router from "./routes/Router";
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

const App = () => {
  const [loading, setLoading] = useState<boolean>(true);
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(fetchUserProfile()).finally(() => setLoading(false));
  }, [dispatch]);

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <>
      <RouterProvider router={Router} />
      <ToastContainer position="top-right" autoClose={3000} />
    </>
  );
};

export default App;