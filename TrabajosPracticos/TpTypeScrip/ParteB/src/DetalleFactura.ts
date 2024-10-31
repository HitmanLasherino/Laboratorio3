import { Articulo } from "./Articulo";

export class DetalleFactura {
    private cantidad: number;
    private subtotal: number;
    private articulo: Articulo;

    constructor(cantidad: number, articulo: Articulo) {
        this.cantidad = cantidad;
        this.articulo = articulo;
        this.subtotal = 0;
        this.calcularSubTotal();
    }

    public calcularSubTotal(): void {
        this.subtotal = this.cantidad * this.articulo.getPrecio();
    }

    public getSubTotal(): number {
        return this.subtotal;
    }
}