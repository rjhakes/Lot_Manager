import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { Container } from 'semantic-ui-react';
import HomePage from '../../components/home/HomePage';
import logo from '../../logo.svg';
import NavBar from './NavBar';
import './styles.css';

function App() {
  return (
    <>
      <NavBar/>
      <Container className='app-container'>
        <Routes>
          <Route path='/' element={<HomePage />}/>
        </Routes>
      </Container>
    </>
  );
}

export default App;
