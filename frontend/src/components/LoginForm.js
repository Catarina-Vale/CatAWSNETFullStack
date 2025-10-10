import React, { useState } from "react";
import { login } from "../api/userApi";

export default function LoginForm({ onLogin }) {
  const [form, setForm] = useState({ handle: "", password: "" });
  const [msg, setMsg] = useState("");

  const onChange = e => setForm({ ...form, [e.target.name]: e.target.value });

  const onSubmit = async e => {
    e.preventDefault();
    const res = await login(form);
    if (res.token) {
      onLogin(res.token);
    } else {
      setMsg(res.message || JSON.stringify(res));
    }
  };

  return (
    <form onSubmit={onSubmit}>
      <input name="handle" placeholder="Handle" onChange={onChange} required />
      <input name="password" type="password" placeholder="Password" onChange={onChange} required />
      <button type="submit">Login</button>
      <div>{msg}</div>
    </form>
  );
}