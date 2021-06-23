<template>
	<div id="SidePanel" class="col-12 col-md-6 col-lg-4 border-end bg-light px-5 pt-3 overflow-auto">
		<Rainbow />

		<h1 id="TopHeaderBackground2">Hello.</h1>
		<h1 id="TopHeaderBackground">Hello.</h1>
		<h1 id="TopHeader">Hello.</h1>

		<p>
			Good afternoon developer!<br /><br />
			I'm Lewis Johnson, and I hope this website shows I'm capable of a modular front-end aswell as a robust API framework.
		</p>

		<h4>About</h4>

		<p>
			This website is built using a dash of Vue.JS, a sprinkle of Bootstrap and smidge of ASP.NET.<br /><br />

			I hope you can appreciate building any web app from the ground up in a few hours is quite the challenge!
			This website has been built using Mozilla Firefox.
			I have given a quick glance on Google Chrome, but if anything is broken please try Firefox.<br /><br />

			Anyway, enjoy using the API, have a look around the code, and I look forward to hearing back from you.
		</p>

		<h4>Build</h4>

		<h5>Backend</h5>
		<p>
			The .NET API must be run using IIS or Kestrel, using <b>Port 3000</b>.<br />
			Alternatively you may modify the URL used in main.js<br /><br />
			
			You can configure and run the API from either the CLI or Visual Studio 2019.
		</p>

		<h5>Frontend</h5>
		<p>
			The VueJS must use <b>Port 8080</b> otherwise you will get a CORS error.<br />
			Alternatively you may modify the URL used in ScraperApi::api::Startup.cs<br /><br />

			The frontend does use a few npm packages, notably, Vue.JS, Axios and Bootstrap.
			These dependencies must be installed via the CLI using npm.
			You may then serve or deploy the app hassle free... hopefully.
		</p>
	</div>
</template>

<style scoped>
	#TopHeader {
		position: absolute;
		top: 22px;
		left: 60px;
	}

	#TopHeaderBackground {
		position: absolute;
		top: 24px;
		left: 58px;
		color: rgb(234, 234, 234);
	}

	#TopHeaderBackground2 {
		position: absolute;
		top: 25px;
		left: 57px;
		color: white;
	}

	#SidePanel {
		display: block;
		height: calc(100vh - 0.2rem);
	}

	p {
		text-align: justify;
	}
</style>

<script>
	import Rainbow from "./Rainbow.vue";

	const data = {
		// Form data
		url: "",
		keywords: "",
		results: "",

		// Page data
		isLoading: false,
		hasLoaded: false,
		hasError: false,

		errorMessage: "",
	};

	export default {
		data() {
			return data;
		},
		components: {
			Rainbow
		},
		methods: {
			SubmitForm: function (e) {
				e.preventDefault();

				this.AxiosPending();

				let payload = JSON.stringify({
					url: this.url,
					keywords: this.keywords,
				});

				this.axios
					.post("weatherforecast", payload, {
						headers: { "Content-Type": "application/json" },
					})
					.then((res) => {
						this.results = res.data;
						this.AxiosLoaded();
					})
					.catch((err) => {
						this.errorMessage = err;
						this.AxiosError();
					});
			},
			AxiosPending: function () {
				this.isLoading = true;
				this.hasLoaded = false;
				this.hasError = false;
			},
			AxiosLoaded: function () {
				this.isLoading = false;
				this.hasLoaded = true;
				this.hasError = false;
			},
			AxiosError: function () {
				this.isLoading = false;
				this.hasLoaded = false;
				this.hasError = true;
			},
		},
	};
</script>