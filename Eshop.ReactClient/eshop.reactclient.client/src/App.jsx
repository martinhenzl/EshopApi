import React, { useEffect, useState } from "react";
import { fetchProducts } from "./api";

function App() {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        fetchProducts()
            .then(data => {
                setProducts(data);
                setLoading(false);
            })
            .catch(err => {
                console.error(err);
                setLoading(false);
            });
    }, []);

    if (loading) return <p>Loading...</p>;

    return (
        <div>
            <h1>Product List</h1>
            <ul>
                {products.map(p => (
                    <li key={p.id}>
                        <strong>{p.name}</strong> - {p.price} Kè
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default App;
