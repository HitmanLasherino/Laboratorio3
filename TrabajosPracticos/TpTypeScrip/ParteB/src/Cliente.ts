import { Factura } from "./Factura";

export class Cliente {
    private numero: number;
    private razonSocial: string;
    private cuit: number;

    constructor(numero: number, razonSocial: string, cuit: number) {
        this.numero = numero;
        this.razonSocial = razonSocial;
        this.cuit = cuit;
    }

    public totalFacturadoXTipoPago(facturas: Factura[], tipoPago: string): number {
        return facturas
            .filter(factura => factura.getTipoPago() === tipoPago)
            .reduce((total, factura) => total + factura.getTotalFinal(), 0);
    }
}