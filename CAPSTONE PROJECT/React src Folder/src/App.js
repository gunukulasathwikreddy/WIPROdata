import { BrowserRouter, Route, Routes } from 'react-router-dom';
import HomePage from './pages/HomePage';
import RegisterPage from './pages/RegisterPage';
import GuestPage from './pages/GuestPage';
import LoginPage from './pages/LoginPage';
import UserPage from './pages/UserPage';
import ResumeBuilderPage from './pages/ResumeBuilderPage';
import ResumePreviewPage from './pages/ResumePreviewPage';
import TestPage from './components/TestPage';


function App() {
  return (
    <div className="App">
      <BrowserRouter>
      <Routes>
         <Route path="/" element={<HomePage/>} />
         <Route path="/login" element={<LoginPage/>} />
         <Route path="/register" element={<RegisterPage/>} />
         <Route path="/guest" element={<GuestPage/>} />
         <Route path="/test" element={<TestPage />} />
         <Route path="/user" element={<UserPage />} />
         <Route path="/resumebuilder" element={<ResumeBuilderPage />}/>
         <Route path="/preview/:resumeId" element={<ResumePreviewPage />} />

         
      </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
