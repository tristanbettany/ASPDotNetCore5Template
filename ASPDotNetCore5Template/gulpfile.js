const gulp = require('gulp');
const babel = require('gulp-babel');
const plumber = require('gulp-plumber');
const sass = require('gulp-sass');
const autoprefixer = require('gulp-autoprefixer');
const minifycss = require('gulp-clean-css');
const rename = require('gulp-rename');
const uglify = require('gulp-uglify');
const concat = require('gulp-concat');
const postcss = require('gulp-postcss');
const tailwindcss = require('tailwindcss');

compileSass = () => {
    return gulp.src('./Views/_SASS/main.scss')
        .pipe(plumber())
        .pipe(sass({ errLogToConsole: true }))
        .pipe(autoprefixer({ overrideBrowserslist: ['last 2 version'] }))
        .pipe(postcss([
            tailwindcss('./tailwind.config.js'),
            require('autoprefixer'),
        ]))
        .pipe(rename({ suffix: '.min' }))
        .pipe(minifycss())
        .pipe(gulp.dest('./wwwroot/css'))
}

compileJs = () => {
    return gulp.src('./Views/_JS/**/*.js')
        .pipe(babel({
            presets: ['@babel/env']
        }))
        .pipe(concat('main.js'))
        .pipe(uglify())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./wwwroot/js'))
}

compileAll = () => {
    compileSass()
    compileJs()
}

gulp.task('sass', (done) => {
    compileSass()
    done()
});
gulp.task('js', (done) => {
    compileJs()
    done()
});
gulp.task('compile', (done) => {
    compileAll()
    done()
});

gulp.task('watch-sass', (done) => {
    gulp.watch('./Views/_SASS/**/*.scss', ['sass']);
    gulp.watch('./tailwind.config.js', ['sass']);
    done()
});

gulp.task('watch-js', (done) => {
    gulp.watch('./Views/_JS/**/*.js', ['js']);
    done()
});

gulp.task('default', (done) => {
    gulp.watch('./Views/_SASS/**/*.scss', ['sass']);
    gulp.watch('./Views/_JS/**/*.js', ['js']);
    gulp.watch('./tailwind.config.js', ['sass']);
    done()
});