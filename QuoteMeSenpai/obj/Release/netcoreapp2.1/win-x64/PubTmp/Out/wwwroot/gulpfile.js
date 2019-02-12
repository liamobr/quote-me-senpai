const gulp = require('gulp');
const sass = require('gulp-sass');
const autoprefixer = require('gulp-autoprefixer');

gulp.task('scss', function () {
    return gulp.src('src/scss/*.scss')
        .pipe(sass({
            includePaths: 'node_modules/foundation-sites/scss'
        }))
        .pipe(sass().on('error', sass.logError))
        .pipe(autoprefixer({
            browsers: ['last 2 versions'],
            cascade: false
        }))
        .pipe(gulp.dest('dist/css'))
});

gulp.task('scss:watch', function () {
    gulp.watch('src/scss/**/*.scss', ['scss'])
});

gulp.task('watch', ['scss', 'scss:watch']);