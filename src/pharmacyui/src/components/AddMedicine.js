import { useState } from "react";

function AddMedicine({ onAdd }) {

    const [medicine, setMedicine] = useState({
        fullName: "",
        brand: "",
        expiryDate: "",
        quantity: "",
        price: "",
        notes: ""
    });

    function handleChange(e) {

        setMedicine({
            ...medicine,
            [e.target.name]: e.target.value
        });

    }

    async function handleSubmit(e) {

        e.preventDefault();

        await onAdd({
            ...medicine,
            quantity: Number(medicine.quantity),
            price: Number(medicine.price)
        });

        setMedicine({
            fullName: "",
            brand: "",
            expiryDate: "",
            quantity: "",
            price: "",
            notes: ""
        });

    }

    return (

        <form className="form" onSubmit={handleSubmit}>

            <input
                name="fullName"
                placeholder="Medicine Name"
                value={medicine.fullName}
                onChange={handleChange}
                required
            />

            <input
                name="brand"
                placeholder="Brand"
                value={medicine.brand}
                onChange={handleChange}
                required
            />

            <input
                type="date"
                name="expiryDate"
                value={medicine.expiryDate}
                onChange={handleChange}
                required
            />

            <input
                type="number"
                name="quantity"
                placeholder="Quantity"
                value={medicine.quantity}
                onChange={handleChange}
                required
            />

            <input
                type="number"
                step="0.01"
                name="price"
                placeholder="Price"
                value={medicine.price}
                onChange={handleChange}
                required
            />

            <textarea
                name="notes"
                placeholder="Notes"
                value={medicine.notes}
                onChange={handleChange}
            />

            <button type="submit">

                Add Medicine

            </button>

        </form>

    );

}

export default AddMedicine;