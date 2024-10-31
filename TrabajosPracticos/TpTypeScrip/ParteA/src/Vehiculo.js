"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Vehiculo = void 0;
class Vehiculo {
    constructor(patente, marca, modelo) {
        this.hojasRuta = [];
        this.patente = patente;
        this.marca = marca;
        this.modelo = modelo;
    }
    getPatente() {
        return this.patente;
    }
    getMarca() {
        return this.marca;
    }
    getModelo() {
        return this.modelo;
    }
    agregarHojaRuta(hojaRuta) {
        this.hojasRuta.push(hojaRuta);
    }
    calcularTotalKmRecorrido(fechaDesde, fechaHasta) {
        let totalKilometros = 0;
        for (const hoja of this.hojasRuta) {
            if (hoja.getFecha() >= fechaDesde && hoja.getFecha() <= fechaHasta) {
                totalKilometros += hoja.calcularTotalKilometros();
            }
        }
        return totalKilometros;
    }
}
exports.Vehiculo = Vehiculo;
