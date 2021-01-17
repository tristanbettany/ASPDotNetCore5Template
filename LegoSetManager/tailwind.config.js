const colors = require('tailwindcss/colors')

let SpacingObject = {};
let Spacing = 5;
for (i = 0; i < 100; i++) {
    SpacingObject[Spacing + 'px'] = Spacing + 'px';
    SpacingObject[Spacing + '%'] = Spacing + '%';
    Spacing += 5;
}

let FontSizeObject = {};
let Size = 2;
for (i = 0; i < 200; i++) {
    FontSizeObject[Size + 'px'] = Size + 'px';
    Size += 2;
}

module.exports = {
    purge: [],
    darkMode: false, // or 'media' or 'class'
    theme: {
        extend: {},
        colors: {
            transparent: 'transparent',
            current: 'currentColor',
            black: '#22292f',
            white: colors.white,
            gray: colors.blueGray,
            grey: colors.blueGray,
            teal: colors.teal,
            yellow: colors.yellow,
        },
        spacing: SpacingObject,
        fontSize: FontSizeObject,
    },
    variants: {
        extend: {},
    },
    plugins: [],
}