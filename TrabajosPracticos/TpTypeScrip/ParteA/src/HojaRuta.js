"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.HojaRuta = void 0;
class HojaRuta {
    constructor(fecha, numero) {
        this.detalles = [];
        this.fecha = fecha;
        this.numero = numero;
    }
    // Getter y Setter
    getFecha() {
        return this.fecha;
    }
    getNumero() {
        return this.numero;
    }
    agregarDetalle(detalle) {
        this.detalles.push(detalle);
    }
    calcularTotalKilometros() {
        let totalKilometros = 0;
        for (const detalle of this.detalles) {
            totalKilometros += detalle.getKmRegreso() - detalle.getKmSalida();
        }
        return totalKilometros;
    }
}
exports.HojaRuta = HojaRuta;
