export class Detalle {
    private kmSalida: number;
    private kmRegreso: number;
    private horaSalida: number;
    private horaRegreso: number;
    private minutoSalida: number;
    private minutoRegreso: number;

    constructor(kmSalida: number, kmRegreso: number, horaSalida: number, horaRegreso: number, minutoSalida: number, minutoRegreso: number) {
        this.kmSalida = kmSalida;
        this.kmRegreso = kmRegreso;
        this.horaSalida = horaSalida;
        this.horaRegreso = horaRegreso;
        this.minutoSalida = minutoSalida;
        this.minutoRegreso = minutoRegreso;
    }

    // Getters
    public getKmSalida(): number {
        return this.kmSalida;
    }

    public getKmRegreso(): number {
        return this.kmRegreso;
    }
}
