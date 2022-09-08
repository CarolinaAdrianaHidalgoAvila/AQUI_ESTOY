import React, { useState, useEffect } from 'react';
import { Avatar } from '@mui/material';
import NavTab from '../components/NavTab';

function UserProfile(props) {
    const { user, ...rest } = props;
    const [value, setValue] = useState(0);

    function handleChange(event, newValue) {
        setValue(newValue);
    }
    

    return (
        <div id='user-profile' className='container m-2'>
            <div className='row align-items-start my-4'>
                <div className='col col-sm-4'>
                    <Avatar alt="Remy Sharp" src="https://img.freepik.com/free-photo/pleasant-looking-serious-man-stands-profile-has-confident-expression-wears-casual-white-t-shirt_273609-16959.jpg?w=2000" sx={{ width: 250, height: 250 }}> Remy Sharp </Avatar>
                </div>
                <div className='col-lg-auto my-auto'>
                    <h1>Remy Sharp</h1>
                    <h5>remyShrp@gmail.com</h5>
                    <h5>+591 70233452</h5>
                </div>
            </div>
            <div className='my-3'>
                <NavTab options={["Publicaciones", "Mascotas", "Informacion"]} onChange={handleChange} value={value}/>
            </div>
            {(value === 0) && <p>Aqui las Publicaciones</p>}
            {(value === 1) && <p>Aqui las Mascotas</p>}
            {(value === 2) && <p>Aqui las Informacion Detallada</p>}
        </div> 
     );
}

export default UserProfile;