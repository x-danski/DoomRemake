use std::io;

struct RgbColor {
    red: u8,
    green: u8,
    blue: u8,
}

impl RgbColor {
    fn new(red: u8, green: u8, blue: u8) -> Self {
        RgbColor {
            red,
            green,
            blue,
        }
    }

    fn change_color(&mut self, red: u8, green: u8, blue: u8) {
        self.red = red;
        self.green = green;
        self.blue = blue;
    }

    fn display(&self) {
        println!("RGB color: R={}, G={}, B={}", self.red, self.green, self.blue);
    }
}

fn main() {
    let mut color = RgbColor::new(255, 0, 0);

    loop {
        color.display();

        println!("Enter new RGB values (0-255) separated by spaces:");
        let mut input = String::new();
        io::stdin().read_line(&mut input).expect("Failed to read line");

        let values: Vec<u8> = input
            .split_whitespace()
            .filter_map(|x| x.parse().ok())
            .collect();

        if values.len() == 3 {
            let red = values[0];
            let green = values[1];
            let blue = values[2];

            color.change_color(red, green, blue);
        } else {
            println!("Invalid input. Please enter three valid RGB values.");
        }
    }
}
