class start extends Phaser.Scene {
    constructor() {
        super("Start");
    }

    preload() { 
        this.load.image("imagens","assets/imagens.png")
    }
  

    create() {
        this.add
            .image(400, 225, "imagens")
            .setInteractive()
            .on("pointerdown", () => {
                this.scene.stop();
                this.scene.start("Preloader");


            })
    }    

    update() { }
}

export default start;