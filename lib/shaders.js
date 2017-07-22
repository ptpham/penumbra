
var glslify = require('glslify');

module.exports = {
  vs: {
    simple: glslify('../glsl/simple.vs')
  },
  fs: {
    red: glslify('../glsl/red.fs')
  }
};

