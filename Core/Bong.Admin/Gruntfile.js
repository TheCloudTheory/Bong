const sass = require('node-sass');

module.exports = function (grunt) {
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        concat: {
            lib: {
                src: [
                    'node_modules/react/umd/react.development.js',
                    'node_modules/react-dom/umd/react-dom.development.js',
                    'node_modules/react-router/umd/react-router.js',
                    'node_modules/react-router-dom/umd/react-router-dom.js'
                ],
                dest: 'dist/lib.js',
            },
        },
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
        browserify: {
            dist: {
                files: {
                    'dist/app.js': ['src/**/*.ts', 'src/**/*.tsx', 'src/**/*.d.ts']
                },
                external: 'react',
                options: {
                    plugin: [
                        ['tsify', { noImplicitAny: true }]
                    ]
                }
            }
        },
        watch: {
            scripts: {
                files: ['src/**/*.tsx', 'src/**/*.ts', 'styles/*.scss'],
                tasks: ['reload'],
                options: {
                    spawn: false,
                    livereload: true
                },
            }
        },
        copy: {
            css: {
                files: [
                    {
                        expand: true,
                        cwd: 'node_modules',
                        src: ['spectre.css/dist/spectre-exp.min.css', 'spectre.css/dist/spectre-icons.min.css'],
                        dest: 'dist/',
                        flatten: true
                    }
                ]
            }
        },
        sass: {
            options: {
                implementation: sass,
                sourceMap: true
            },
            dist: {
                files: {
                    'dist/bong.css': 'styles/bong.scss'
                }
            }
        }
    });

    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-connect');
    grunt.loadNpmTasks('grunt-browserify');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-sass');

    grunt.registerTask('default', ['concat', 'sass', 'copy', 'browserify', 'connect', 'watch']);
    grunt.registerTask('reload', ['concat', 'sass', 'copy', 'browserify']);
    grunt.registerTask('build', ['concat', 'sass', 'copy', 'browserify']);
};