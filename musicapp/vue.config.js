const { defineConfig } = require('@vue/cli-service')
module.exports = {
  transpileDependencies: true,
};
module.exports = {
  publicPath: process.env.NODE_ENV === 'production'
    ? '/Emne4/'  // replace with your repo name (case-sensitive)
    : '/'
}