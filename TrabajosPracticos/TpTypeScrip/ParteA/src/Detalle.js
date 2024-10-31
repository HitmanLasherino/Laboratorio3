"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Detalle = void 0;
class Detalle {
    constructor(kmSalida, kmRegreso, horaSalida, horaRegreso, minutoSalida, minutoRegreso) {
        this.kmSalida = kmSalida;
        this.kmRegreso = kmRegreso;
        this.horaSalida = horaSalida;
        this.horaRegreso = horaRegreso;
        this.minutoSalida = minutoSalida;
        this.minutoRegreso = minutoRegreso;
    }
    // Getters
    getKmSalida() {
        return this.kmSalida;
    }
    getKmRegreso() {
        return this.kmRegreso;
    }
}
exports.Detalle = Detalle;
