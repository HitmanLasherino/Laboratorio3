"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DetalleFactura = void 0;
class DetalleFactura {
    constructor(cantidad, articulo) {
        this.cantidad = cantidad;
        this.articulo = articulo;
        this.subtotal = 0;
        this.calcularSubTotal();
    }
    calcularSubTotal() {
        this.subtotal = this.cantidad * this.articulo.getPrecio();
    }
    getSubTotal() {
        return this.subtotal;
    }
}
exports.DetalleFactura = DetalleFactura;
