"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Factura = void 0;
class Factura {
    constructor(letra, numero, recargo, tipoPago, cliente) {
        this.letra = letra;
        this.numero = numero;
        this.recargo = recargo;
        this.tipoPago = tipoPago;
        this.totalItems = 0;
        this.totalFinal = 0;
        this.cliente = cliente;
        this.fecha = new Date();
        this.detalles = [];
    }
    agregarDetalle(detalle) {
        this.detalles.push(detalle);
    }
    calcularTotalItems() {
        this.totalItems = this.detalles.reduce((total, detalle) => total + detalle.getSubTotal(), 0);
    }
    calcularTotalFinal() {
        this.calcularTotalItems();
        this.totalFinal = this.totalItems + this.recargo;
    }
    getTotalFinal() {
        return this.totalFinal;
    }
    getTipoPago() {
        return this.tipoPago;
    }
}
exports.Factura = Factura;
