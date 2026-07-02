import { useState } from "react";

function MedicineList({ medicines }) {

    const [search, setSearch] = useState("");

    const filtered = medicines.filter(x =>
        x.fullName.toLowerCase().includes(search.toLowerCase())
    );

    function getClass(medicine) {

        const today = new Date();

        const expiry = new Date(medicine.expiryDate);

        const days = (expiry - today) / (1000 * 60 * 60 * 24);

        if (days < 30)
            return "expiry";

        if (medicine.quantity < 10)
            return "lowStock";

        return "";
    }

    return (

        <>

            <input
                className="search"
                placeholder="Search medicine..."
                value={search}
                onChange={(e) => setSearch(e.target.value)}
            />

            <table>

                <thead>

                    <tr>

                        <th>Name</th>
                        <th>Brand</th>
                        <th>Expiry</th>
                        <th>Quantity</th>
                        <th>Price</th>

                    </tr>

                </thead>

                <tbody>

                    {filtered.map(m => (

                        <tr key={m.id} className={getClass(m)}>

                            <td>{m.fullName}</td>

                            <td>{m.brand}</td>

                            <td>{m.expiryDate.substring(0,10)}</td>

                            <td>{m.quantity}</td>

                            <td>₹ {m.price}</td>

                        </tr>

                    ))}

                </tbody>

            </table>

        </>

    );

}

export default MedicineList;