import { Articulo } from "./Articulo";
import { DetalleFactura } from "./DetalleFactura";
import { Factura } from "./Factura";
import { Cliente } from "./Cliente";

export class TestB {
    public static main(): void {
        // Crear cliente
        const cliente = new Cliente(1, "Empresa XYZ", 20304050607);

        // Crear artículos
        const art1 = new Articulo(1, "Producto A", 100.0, "unidad");
        const art2 = new Articulo(2, "Producto B", 200.0, "unidad");
        const art3 = new Articulo(3, "Producto C", 300.0, "unidad");
        const art4 = new Articulo(4, "Producto D", 400.0, "unidad");
        const art5 = new Articulo(5, "Producto E", 500.0, "unidad");

        // Crear facturas
        const factura1 = new Factura("A", 1, 50.0, "E", cliente);
        const factura2 = new Factura("B", 2, 100.0, "TD", cliente);
        const factura3 = new Factura("C", 3, 0.0, "CC", cliente);

        // Agregar detalles a las facturas
        factura1.agregarDetalle(new DetalleFactura(2, art1));
        factura1.agregarDetalle(new DetalleFactura(3, art2));
        factura2.agregarDetalle(new DetalleFactura(1, art3));
        factura2.agregarDetalle(new DetalleFactura(5, art4));
        factura3.agregarDetalle(new DetalleFactura(10, art5));

        // Calcular totales
        factura1.calcularTotalFinal();
        factura2.calcularTotalFinal();
        factura3.calcularTotalFinal();

        // Listar facturas del cliente
        const facturasCliente: Factura[] = [factura1, factura2, factura3];

        // Total facturado por tipo de pago
        console.log("Total facturado en efectivo: " + cliente.totalFacturadoXTipoPago(facturasCliente, "E"));
        console.log("Total facturado con tarjeta de crédito: " + cliente.totalFacturadoXTipoPago(facturasCliente, "TD"));
    }
}

// Ejecutar el test
TestB.main();