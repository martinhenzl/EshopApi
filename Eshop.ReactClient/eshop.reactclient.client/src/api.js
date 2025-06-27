const API_BASE = "https://localhost:7036/api";

export async function fetchProducts() {
    const response = await fetch(`${API_BASE}/products/all`);
    if (!response.ok) throw new Error("Failed to fetch products");
    return await response.json();
}
