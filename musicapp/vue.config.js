const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true
})
module.exports = {
  publicPath: process.env.NODE_ENV === 'production'
    ? '/Emne4/musicapp/'  // replace with your repo name (case-sensitive)
    : '/'
}