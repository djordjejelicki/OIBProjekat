import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { AuthProvider } from "./auth/AuthProvider";
import ProtectedRoute from "./auth/ProtectedRoute";

import LoginPage from "./pages/LoginPage";
import ManagerDashboard from "./pages/ManagerDashboard";
import SellerDashboard from "./pages/SellerDashboard";
import AddPetPage from "./pages/AddPetPage";
import AllPetsPage from "./pages/AllPetsPage";
import InvoicesPage from "./pages/InvoicePage";
import "./styles/App.css";

function App() {
  return (
    <AuthProvider>
      <div className="app-container">
        <BrowserRouter>
          <Routes>
            <Route path="/" element={<Navigate to="/login" />} />
            <Route path="/login" element={<LoginPage/>}/>
            <Route path="/manager" element={
              <ProtectedRoute>
                <ManagerDashboard/>
              </ProtectedRoute>
            }/>
            <Route path="/manager/add-pet" element={
              <ProtectedRoute>
                  <AddPetPage />
              </ProtectedRoute>
            }/>
            <Route path="/manager/pets" element={
              <ProtectedRoute>
                <AllPetsPage />
              </ProtectedRoute>
            }/>
            <Route path="/manager/invoices" element={
              <ProtectedRoute>
                  <InvoicesPage />
              </ProtectedRoute>
            }/>
            <Route path="/seller" element={
              <ProtectedRoute>
                <SellerDashboard/>
              </ProtectedRoute>
            }/>
          </Routes>
        </BrowserRouter>
      </div>
    </AuthProvider>
  );
}

export default App;
