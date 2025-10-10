import React, { useState } from "react";
import { updateProfile, uploadProfilePic } from "../api/userApi";

export default function ProfileForm({ token }) {
  const [form, setForm] = useState({ displayName: "", bio: "" });
  const [file, setFile] = useState(null);
  const [msg, setMsg] = useState("");

  const onChange = e => setForm({ ...form, [e.target.name]: e.target.value });

  const onProfileUpdate = async e => {
    e.preventDefault();
    const res = await updateProfile(token, form);
    setMsg(res.message || JSON.stringify(res));
  };

  const onPicUpload = async e => {
    e.preventDefault();
    if (!file) return;
    const res = await uploadProfilePic(token, file);
    setMsg(res.message || JSON.stringify(res));
  };

  return (
    <div>
      <form onSubmit={onProfileUpdate}>
        <input name="displayName" placeholder="Display Name" onChange={onChange} />
        <input name="bio" placeholder="Bio" onChange={onChange} />
        <button type="submit">Update Profile</button>
      </form>
      <form onSubmit={onPicUpload}>
        <input type="file" onChange={e => setFile(e.target.files[0])} />
        <button type="submit">Upload Profile Picture</button>
      </form>
      <div>{msg}</div>
    </div>
  );
}