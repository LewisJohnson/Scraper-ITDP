<template>
	<div class="rainbow mb-3">
		<div v-bind:class="classes[0].class"></div>
		<div v-bind:class="classes[1].class"></div>
		<div v-bind:class="classes[2].class"></div>
		<div v-bind:class="classes[3].class"></div>
		<div v-bind:class="classes[4].class"></div>
		<div v-bind:class="classes[5].class"></div>
	</div>
</template>

<style scoped>
	.rainbow div {
		display: block;
		width: 100%;
		height: 10px;
	}

	.rainbow-colour-1 {
		background-color: #ff9aa2;
	}

	.rainbow-colour-2 {
		background-color: #ffb7b2;
	}

	.rainbow-colour-3 {
		background-color: #ffdac1;
	}

	.rainbow-colour-4 {
		background-color: #e2f0cb;
	}

	.rainbow-colour-5 {
		background-color: #b5ead7;
	}

	.rainbow-colour-6 {
		background-color: #c7ceea;
	}
</style>

<script>
	const data = {
		classes: [
			{ class: "rainbow-colour-1" },
			{ class: "rainbow-colour-2" },
			{ class: "rainbow-colour-3" },
			{ class: "rainbow-colour-4" },
			{ class: "rainbow-colour-5" },
			{ class: "rainbow-colour-6" },
		],
	};

	export default {
		data() {
			return data;
		},
		mounted() {
			setInterval(() => this.ChangeColours(), 200);
		},
		created() {
			this.ChangeColours();
		},
		methods: {
			ChangeColours: function () {
				console.log();
				for (let i = 0; i < this.classes.length; i++) {
					const rclass = this.classes[i].class;

					let colourId = parseInt(rclass.charAt(rclass.length - 1));

					if (colourId <= 1) {
						colourId = 6;
					} else {
						colourId--;
					}

					this.classes[i].class = "rainbow-colour-" + colourId;
				}
			},
		},
	};
</script>