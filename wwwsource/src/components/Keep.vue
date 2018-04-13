<template>
    <div class="keep">
        <dashboard></dashboard>
        <div class="px-bkground"></div>
        <div class="container">
            <div class="row d-inline-flex justify-content-center p-2" v-for="keep in keeps">
                <div class="col-sm-12">
                    <img class="thumbnail" :src= keep.imgurl >
                    <p class="card-text">{{keep.description}}</p>
                    <p>Article link <a :href = keep.articleurl class="art-link">here</a></p>
                    <div class="is-public">
                    <span>
                       <p>Mark this keep as Public?</p>
                       <form @submit.prevent="updatePublicPrivate()">
                       <input type="checkbox" name="ispub" value=0>Private<br>
                       <input type="checkbox" name="ispub" value=1>Public<br>
                       <button type="submit" class="btn btn-info">Submit</button>
                    </form>
                    </span>
                    </div>
                    <div class="container">
                        <div class="row justify-content-around m-2">
                            <div class="col-xs-4">Views: {{keep.nbrviews}}</div>
                            <div class="col-xs-4">Keeps:  {{keep.nbrkeeps}}</div>
                        </div>
                        <div class="row justify-content-between m-2">
                            <div v-if="!user.id">
                                <div class="col-xs-4"><button type="button" class="btn button btnkeep" @click="keepTheKeep(keep)"></button></div>
                                <div class="col-xs-4"> <button type="button" class="btn button btnshare"></button></div>
                            </div>
                            <!-- <div class="col-xs-4"><button type="button" class="btn button btninspect"></button></div> -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  </template>

<script>
    import Dashboard from './Dashboard'
    export default {
        name: 'Keep',
        components: {
            Dashboard
        },
        data() {
            return {

            }
        },
        props: ['keep'],

        mounted() {
            this.$store.dispatch('getKeepById');
            this.$store.dispatch('updateViewCount')
        },
        computed: {
            keep() {
                return this.$store.state.keeps[this.keep.Id] || []
            }
        },
        methods: {
            keepTheKeep(keep) {
                this.$store.dispatch('keepTheKeep')
            }

        }

    }
</script>


<style scoped>
    .btnkeep {
        background-image: url(../assets/btnkeep.png);
        background-repeat: no-repeat;
        /* background-position: 0px 0px; */
        border: none;
        cursor: pointer;
        height: 40px;
        width: 40px;
        vertical-align: bottom;
    }
    
    .btnshare {
        background-image: url(../assets/btnshare.png);
        background-repeat: no-repeat;
        /* background-position: 0px 0px; */
        border: none;
        cursor: pointer;
        height: 40px;
        width: 40px;
        vertical-align: bottom;
    }
    
    .btninspect {
        background-image: url(../assets/btninspect.png);
        background-repeat: no-repeat;
        /* background-position: 0px 0px; */
        border: none;
        cursor: pointer;
        height: 40px;
        width: 40px;
        vertical-align: bottom;
    }
    
    .card-layout {
        width: 15rem;
        height: 25rem;
    }
    
    .card-layout h5 {
        font-size: 12pt;
        text-align: center;
    }
    
    .card-layout p {
        font-size: 11pt;
        text-align: center;
    }
    
    h1 {
        color: white;
    }
    
    .rtr-lnk {
        background-color: #38437c;
        color: white;
        transition: all .3s linear;
    }
    
    .rtr-lnk hover {
        background-color: #8f9fff;
        color: yellow;
    }
    
    .thumbnail {
        height: 120px;
        width: 120px;
        align-self: center;
    }
    
    .art-link {
        color: yellow;
    }
    
    .hoverstuff {
        align-items: center;
    }
    
    .hidestuff {
        padding: 20px;
        visibility: hidden;
        cursor: pointer;
    }
    
    .hoverdiv {
        width: 100%;
    }
    
    .hoverspan:hover .hidestuff {
        visibility: visible;
        cursor: pointer;
        width: 100%;
    }
</style>