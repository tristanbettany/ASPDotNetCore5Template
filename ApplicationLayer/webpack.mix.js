const mix = require('laravel-mix');

mix
    .setPublicPath('wwwroot')
    .js('Resources/Javascript/main.js', 'wwwroot/js/main.min.js')
    .sass('Resources/Sass/main.scss', 'wwwroot/css/main.min.css')
    .sourceMaps()
    .options({
        postCss: [
            require("tailwindcss"),
        ]
    })
    .version();
