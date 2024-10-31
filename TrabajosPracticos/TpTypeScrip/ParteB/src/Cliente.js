"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Cliente = void 0;
class Cliente {
    constructor(numero, razonSocial, cuit) {
        this.numero = numero;
        this.razonSocial = razonSocial;
        this.cuit = cuit;
    }
    totalFacturadoXTipoPago(facturas, tipoPago) {
        return facturas
            .filter(factura => factura.getTipoPago() === tipoPago)
            .reduce((total, factura) => total + factura.getTotalFinal(), 0);
    }
}
exports.Cliente = Cliente;
