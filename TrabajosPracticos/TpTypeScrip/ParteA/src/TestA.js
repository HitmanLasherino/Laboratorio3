"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const Detalle_1 = require("./Detalle");
const HojaRuta_1 = require("./HojaRuta");
const Vehiculo_1 = require("./Vehiculo");
class TestA {
    static main() {
        //Crear Vehículo
        const vehiculo = new Vehiculo_1.Vehiculo("ABC123", "Toyota", "Corolla");
        //Crear Hojas de Ruta
        const hoja1 = new HojaRuta_1.HojaRuta(new Date(2024, 9, 1), 1);
        const hoja2 = new HojaRuta_1.HojaRuta(new Date(2024, 9, 2), 2);
        const hoja3 = new HojaRuta_1.HojaRuta(new Date(2024, 9, 3), 3);
        //Crear detalles y agregarlos a las hojas de ruta
        hoja1.agregarDetalle(new Detalle_1.Detalle(100, 200, 8, 10, 30, 45));
        hoja1.agregarDetalle(new Detalle_1.Detalle(200, 300, 11, 13, 15, 30));
        hoja2.agregarDetalle(new Detalle_1.Detalle(150, 250, 9, 11, 0, 15));
        hoja2.agregarDetalle(new Detalle_1.Detalle(250, 350, 14, 16, 45, 55));
        hoja3.agregarDetalle(new Detalle_1.Detalle(300, 400, 10, 12, 5, 30));
        hoja3.agregarDetalle(new Detalle_1.Detalle(400, 500, 13, 15, 15, 45));
        //Agregar las hojas de ruta al vehículo
        vehiculo.agregarHojaRuta(hoja1);
        vehiculo.agregarHojaRuta(hoja2);
        vehiculo.agregarHojaRuta(hoja3);
        //Calcular y mostrar resultados
        const totalKm = vehiculo.calcularTotalKmRecorrido(new Date(2024, 9, 1), new Date(2024, 9, 3));
        console.log(`Total kilómetros recorridos: ` + totalKm);
    }
}
TestA.main();
