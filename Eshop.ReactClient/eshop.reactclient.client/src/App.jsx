import React, { useEffect, useState, useRef } from "react";
import axios from "axios";

function App() {
    const [products, setProducts] = useState([]);           // Array to hold product data
    const [descriptions, setDescriptions] = useState({});   // Object to hold descriptions for each product
    const [errors, setErrors] = useState({});               // Object to hold error messages for each product
    const [isLoading, setIsLoading] = useState(true);       // Loading state to show spinner while fetching data
    const inputRefs = useRef({});                           // Ref to hold input elements for each product description

    useEffect(() => {
        axios.get("https://localhost:7036/api/products/all")
            .then(response => {
                setProducts(response.data);
                const initialDescriptions = {};
                response.data.forEach(product => {
                    initialDescriptions[product.id] = product.description || "";
                });
                setDescriptions(initialDescriptions);
            })
            .catch(error => {
                console.error("Chyba při načítání produktů:", error);
            })
            .finally(() => {
                setIsLoading(false);
            });
    }, []);

    // Handle description change for a specific product
    const handleDescriptionChange = (id, newDescription) => {
        setDescriptions(prev => ({
            ...prev,
            [id]: newDescription
        }));
    };

    const handleUpdateDescription = (id) => {
        const updatedDescription = descriptions[id].trim();

        // Validate the description length
        if (updatedDescription.length > 10000) {
            setErrors(prev => ({ ...prev, [id]: "Popis nesmí překročit 10000 znaků!" }));

            // Focus on the input field for the current product
            const input = inputRefs.current[id];
            if (input) {
                input.focus();
                input.select();
            }

            // Reset error after 3 seconds
            setTimeout(() => {
                setErrors(prev => ({ ...prev, [id]: null }));
            }, 3000);

            return;
        }
        setErrors(prev => ({ ...prev, [id]: null }));

        // Update the product description via API
        axios.patch(`https://localhost:7036/api/products/${id}`, {
            description: updatedDescription
        })
            .then(() => {
                setProducts(prev =>
                    prev.map(p =>
                        p.id === id ? { ...p, description: updatedDescription } : p
                    )
                );
            })
            .catch(error => {
                console.error("Chyba při aktualizaci:", error);
            });
    };

    // If loading, show a spinner
    if (isLoading) {
        return (
            <div style={{
                position: "fixed",
                top: "50%",
                left: "50%",
                transform: "translate(-50%, -50%)",
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
                justifyContent: "center"
            }}>
                <div style={{
                    border: "8px solid #f3f3f3",
                    borderTop: "8px solid #3498db",
                    borderRadius: "50%",
                    width: "60px",
                    height: "60px",
                    animation: "spin 1s linear infinite"
                }} />
                <p style={{ marginTop: "1rem", fontSize: "1.2rem" }}>Načítám produkty...</p>

                <style>{`
                @keyframes spin {
                    0% { transform: rotate(0deg); }
                    100% { transform: rotate(360deg); }
                }
            `}</style>
            </div>
        );
    }

    // Show Product List
    return (
        <div style={{ padding: "2rem" }}>
            <h1>Seznam produktů</h1>
            {products.map(product => (
                <div key={product.id} style={{ marginBottom: "1.5rem", borderBottom: "1px solid #ccc", paddingBottom: "1rem" }}>
                    <div><strong>Název:</strong> {product.name}</div>
                    <div><strong>Cena:</strong> {product.price} Kč</div>
                    <div><strong>Popis:</strong> {product.description}</div>

                    <input
                        type="text"
                        value={descriptions[product.id] || ""}
                        onChange={(e) => handleDescriptionChange(product.id, e.target.value)}
                        placeholder="Změnit popis"
                        ref={(el) => inputRefs.current[product.id] = el}
                        style={{ marginTop: "0.5rem", marginRight: "0.5rem", width: "60%" }}
                    />
                    <button onClick={() => handleUpdateDescription(product.id)}>Uložit změnu</button>
                    {errors[product.id] && (
                        <div style={{ color: "red", marginTop: "0.25rem" }}>{errors[product.id]}</div>
                    )}
                </div>
            ))}
        </div>
    );
}

export default App;
