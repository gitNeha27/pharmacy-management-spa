import './App.css';
import { useEffect, useState } from 'react';
import { getMedicines, addMedicine } from './services/medicineService';
import AddMedicine from './components/AddMedicine';
import MedicineList from './components/MedicineList';

function App() {

    const [medicines, setMedicines] = useState([]);

    async function loadMedicines() {

        try {

            const data = await getMedicines();

            setMedicines(data);

        }
        catch (error) {

            console.error(error);

        }

    }

    useEffect(() => {

        loadMedicines();

    }, []);

    async function handleAdd(medicine) {

       await addMedicine(medicine);

await loadMedicines();

    }

    return (

        <div className="container">

            <h1>ABC Pharmacy</h1>

            <AddMedicine onAdd={handleAdd} />

            <MedicineList medicines={medicines} />

        </div>

    );

}

export default App;