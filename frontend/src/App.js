import React, { useState } from "react";
import RegisterForm from "./components/RegisterForm";
import LoginForm from "./components/LoginForm";
import ProfileForm from "./components/ProfileForm";

function App() {
  const [token, setToken] = useState(null);

  return (
    <div>
      <h1>CatAWSNETFullStack User Management</h1>
      {!token ? (
        <>
          <h2>Register</h2>
          <RegisterForm />
          <h2>Login</h2>
          <LoginForm onLogin={setToken} />
        </>
      ) : (
        <>
          <h2>Profile</h2>
          <ProfileForm token={token} />
        </>
      )}
    </div>
  );
}

export default App;