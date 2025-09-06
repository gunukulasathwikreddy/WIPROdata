import axios from "axios";

// Create an axios instance
const api = axios.create({
  baseURL: "http://localhost:5178", // your backend API base URL
});

// Add a request interceptor to attach JWT token automatically
api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem("jwtToken");
    if (token) {
      config.headers.Authorization = token; // keep it raw, no "Bearer"
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);


api.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response && error.response.status === 401) {
      const requestUrl = error.config?.url?.toLowerCase() || "";

      
      if (
        requestUrl.includes("/api/auth/login") ||
        requestUrl.includes("/api/auth/register")
      ) {
        return Promise.reject(error); 
      }

      
      localStorage.clear();
      window.location.href = "/login";
    }

    return Promise.reject(error);
  }
);

export default api;