module.exports = function (grunt) {
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        connect: {
            server: {
                options: {
                    port: 12335,
                    hostname: 'localhost',
                    open: true,
                    livereload: true,
                    middleware: function (connect, options, middlewares) {
                        var modRewrite = require('connect-modrewrite');

                        middlewares.unshift(modRewrite(['!/api|\\.html|\\.js|\\.svg|\\.css|\\.png|/$ /index.html [L]',]));

                        return middlewares;
                    }
                }
            }
        },
        watch: {
            scripts: {
                files: ['src/**/*.jsx', 'src/**/*.js', 'styles/*.scss'],
                tasks: ['reload'],
                options: {
                    spawn: false,
                    livereload: true
                },
            }
        }
    });

    grunt.loadNpmTasks('grunt-contrib-connect');
    grunt.loadNpmTasks('grunt-contrib-watch');

    grunt.registerTask('default', ['connect', 'watch']);
};