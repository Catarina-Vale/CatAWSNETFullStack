import React, { useState } from "react";
import { register } from "../api/userApi";

export default function RegisterForm() {
  const [form, setForm] = useState({ handle: "", displayName: "", password: "" });
  const [msg, setMsg] = useState("");

  const onChange = e => setForm({ ...form, [e.target.name]: e.target.value });

  const onSubmit = async e => {
    e.preventDefault();
    const res = await register(form);
    setMsg(res.message || JSON.stringify(res));
  };

  return (
    <form onSubmit={onSubmit}>
      <input name="handle" placeholder="Unique Handle" onChange={onChange} required />
      <input name="displayName" placeholder="Display Name" onChange={onChange} required />
      <input name="password" type="password" placeholder="Password" onChange={onChange} required />
      <button type="submit">Register</button>
      <div>{msg}</div>
    </form>
  );
}