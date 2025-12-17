import React, { useState, useEffect } from "react";
import { AuthContext } from "./AuthContext";
import {jwtDecode} from "jwt-decode";

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(undefined);
    const [loading, setLoading] = useState(true);

    
    const CLAIM_NAME = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
    const CLAIM_ROLE = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

    const decodeToken = (token) => {
        const decoded = jwtDecode(token);
        console.log("Decoded:", decoded);

        return {
            username: decoded[CLAIM_NAME],
            role: decoded[CLAIM_ROLE]
        };
    };

    useEffect(() => {
        const token = localStorage.getItem("token");
        if (token) {
            try {
                setUser(decodeToken(token));
            } catch {
                setUser(null);
            }
        } else {
            setUser(null);
        }

        setLoading(false);
    }, []);

    const login = (token) => {
        localStorage.setItem("token", token);

        try {
            setUser(decodeToken(token));
        } catch {
            setUser(null);
        }
    };

    const logout = () => {
        localStorage.removeItem("token");
        setUser(null);
    };

    return (
        <AuthContext.Provider value={{ user, login, logout, loading }}>
            {children}
        </AuthContext.Provider>
    );
};