        function Init() {

            let input = document.getElementById("searchText")
            input.addEventListener("click",
                function(event) {
                    input.value = "";
                })


            document.getElementById("searching")
                .addEventListener("submit",
                    function(event) {
                        event.preventDefault();
                        let inputText = document.getElementById("searchText").value
                        if (inputText !== "") {
                            loadSongs(inputText)
                        } else {
                            alert("Check your key word !")
                        }
                        return false;
                });


        }


        function loadSongs(inputText) {

            $.ajax({
                url: 'http://api.dragonet.com.pl/api/music/GetSongs?search=' + inputText,
                method: 'GET',
                dataType: "text",
                success: function(data) {
                    let list = new Array();

                    var jsonData = JSON.parse(data);

                    for (let i = 0; i < jsonData.length; i++) {

                        list[i] = (createSongsList(new Song(jsonData[i].SongId,
                            jsonData[i].SongName,
                            jsonData[i].ArtistName,
                            jsonData[i].ArtistImageUrl)))

                    }

                    document.getElementById("songs-items").innerHTML = list.join("")

                }

            })

        }

        class Song {
            constructor(SongId, SongName, ArtistName, ArtistImageUrl) {
                this.SongId = SongId
                this.SongName = SongName
                this.ArtistName = ArtistName
                this.ArtistImageUrl = ArtistImageUrl
            }
        }

        function createSongsList(song) {
            //console.log(song.SongId + " " + song.SongName + " " + song.ArtistName + " " + song.ArtistImageUrl);
            let songHtml = `
                               <div id="${song.SongId}" class="song col-xs-12 col-lg-12" onClick="songClick(this.id)">

                                       <div class="song-image col-xs-4 col-lg-3">
                                            <img src="${song.ArtistImageUrl}" alt="Loading" />

                                        </div>
                                        <div class="song-date col-xs-8 col-lg-9">
                                            <div class="song-date-title col-xs-12 col-lg-12">${song.SongName} </div>
                                            <div class="song-date-artist col-xs-12 col-lg-12">${song.ArtistName}</div>

                                        </div>


                                    </div>
`;
            return songHtml.toString();
        }
        
        function Load() {
            let inputText = document.getElementById("searchText").value
            if (inputText !== "") {
                loadSongs(inputText)
            } else {
                alert("Check your key word !")
            }
        }

        function songClick(songID) {

            //$.ajax({
            //    url: 'http://api.dragonet.com.pl/api/music/ChooseSong?id=' + songID,
            //    method: 'GET',
            //    dataType: "text",
            //    success: function(data) {
            //        var json = $.parseJSON(data);
            //        alert(json);
                 
            //        location.replace("http://api.dragonet.com.pl/Home/PlayerSong");
            //    }

            //})
            localStorage.songID = JSON.stringify(songID);
        }

