<template>
	<div class="row">
		<SidePanel />
		<ScrapeForm />
	</div>
</template>

<script>
	// Internal
	import SidePanel from "./views/SidePanel.vue";
	import ScrapeForm from "./views/ScrapeForm.vue";

	export default {
		name: "App",
		components: {
			SidePanel,
			ScrapeForm,
		},
	};
</script>

<style>
	#app {
		font-family: Avenir, Helvetica, Arial, sans-serif;
		-webkit-font-smoothing: antialiased;
		-moz-osx-font-smoothing: grayscale;
		color: #2c3e50;
		overflow-x: hidden;
	}

	@import "~bootstrap/dist/css/bootstrap.css";
</style>
